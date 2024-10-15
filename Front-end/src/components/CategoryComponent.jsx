import { useEffect, useState } from "react";
import CategoryService from "../services/CategoryService";

const Categorycomponent = () =>{
    const [categories, setCategories]=useState([]);
    const [newCategoryName, setNewCategoryName]=useState('');
    const [editingCategory, setEditingCategory] = useState(null);
    const [editCategoryName, setEditCategoryName] = useState('');

    useEffect(()=>{ fetchCategories(); },[]);


    const fetchCategories = async()=>{
        try
        {
            const response = await CategoryService.getAllCategories();
            setCategories(response.data);
        }
        catch(error)
        {
            console.error('Error in fetching Category Data', error);
            
        }
    };

    const addNewCategory=async (e)=>{
        e.preventDefault();

        const newCategory={
            categoryName:newCategoryName,
        };
        try{
            await CategoryService.createCategory(newCategory);
            setNewCategoryName('');
            fetchCategories();
        }
        catch(error){
            console.error('Error in adding new category', error);
            
        }
    };

    const deleteCategory=async(id)=>{
        try
        {
            await CategoryService.deleteCategory(id);
            fetchCategories();
        }
        catch(error)
        {
            console.error('Error in deleting Category',error);
            
        }
    };

    const handleEdit = (category) => {
        setEditingCategory(category);
        setEditCategoryName(category.categoryName);
    };
    
    const handleUpdate = async (e) => {
        e.preventDefault();
        if (editingCategory) {
            const updatedCategory = {
                categoryName: editCategoryName,
            };
            try {
                await CategoryService.updateCategory(editingCategory.categoryId, updatedCategory);
                setEditingCategory(null);
                setEditCategoryName('');
                fetchCategories(); 
            } catch (error) {
                console.error('Error in updating category:', error);
            }
        }
    };

    return (
        <div>
             <div className="addcategoryForm container mx-auto p-4 mt-6 bg-white shadow-md rounded-lg">
                <h3 className="text-l font-semibold mb-4">
                    {editingCategory ? 'Update Category' : 'Add New Category'}
                </h3>
                <form onSubmit={editingCategory ? handleUpdate : addNewCategory} className="flex items-center space-x-4">
                    <div className="flex-grow">
                        <label htmlFor="categoryName" className="block mb-2 font-medium">
                        Category Name:
                        </label>
                        <div className="flex items-center space-x-2">
                        <input
                            type="text"
                            id="categoryName"
                            className="w-full px-2 py-1 border border-gray-300 rounded-md"
                            value={editingCategory ? editCategoryName : newCategoryName}
                            onChange={(e) =>
                            editingCategory ? setEditCategoryName(e.target.value) : setNewCategoryName(e.target.value)
                            }
                            required
                        />
                        <button
                            type="submit"
                            className={`${
                            editingCategory ? 'bg-yellow-500 hover:bg-yellow-600' : 'bg-green-500 hover:bg-green-600'
                            } text-white py-1 px-3 rounded-md transition`}
                        >
                            {editingCategory ? 'Update' : 'Create'}
                        </button>
                        </div>
                    </div>
                </form>
            </div>

           <div className="showcategories p-5">
            <h1 className="text-2xl font-bold mb-4">Categories List</h1>
            <table className="min-w-full bg-white border border-gray-300">
                <thead>
                <tr className="bg-gray-100">
                    <th className="py-2 px-4 border-b text-left">Category Name</th>
                    <th className="py-2 px-4 border-b text-left">Action Buttons</th>
                </tr>
                </thead>
                <tbody>
                {categories.map((category) => (
                    <tr key={category.categoryId} className="hover:bg-gray-50">
                        <td className="py-2 px-4 border-b">{category.categoryName}</td>
                        <td className="py-2 px-4 border-b">
                            <button
                            className="bg-blue-400 text-white py-1 px-3 rounded-md hover:bg-blue-600 transition"
                            onClick={() => handleEdit(category)}
                            >
                            Edit
                            </button>
                            <button
                            className="bg-red-400 text-white py-1 px-3 ml-2 rounded-md hover:bg-red-600 transition"
                            onClick={() => deleteCategory(category.categoryId)}
                            >
                            Delete
                            </button>
                        </td>
                    </tr>
                ))}
                </tbody>
            </table>
            </div>
        </div>
    );

};

export default Categorycomponent;