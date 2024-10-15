import { useEffect, useState } from "react";
import SubCategoryService from "../services/SubCategoryService";
import CategoryService from "../services/CategoryService";

const SubCategoryComponent = () => {
    const [subcategories, setSubCategories] = useState([]);
    const [categories, setCategories] = useState([]);
    const [newSubCategoryName, setNewSubCategoryName] = useState('');
    const [editingSubCategory, setEditingSubCategory] = useState(null);
    const [editSubCategoryName, setEditSubCategoryName] = useState('');
    const [selectedCategoryId, setSelectedCategoryId] = useState(''); 

    useEffect(() => {
        fetchCategories(); 
        fetchSubCategories(); 
    }, []);

    const fetchSubCategories = async () => {
        try {
            const response = await SubCategoryService.getAllSubCategories();
            setSubCategories(response.data);
        } catch (error) {
            console.error('Error in fetching SubCategory Data', error);
        }
    };

    const fetchCategories = async () => {
        try {
            const response = await CategoryService.getAllCategories(); 
            setCategories(response.data);
        } catch (error) {
            console.error('Error in fetching Category Data', error);
        }
    };

    const addNewSubCategory = async (e) => {
        e.preventDefault();

        const newSubCategory = {
            subcategoryName: newSubCategoryName,
            categoryId: selectedCategoryId, 
        };
        try {
            await SubCategoryService.createSubCategory(newSubCategory);
            setNewSubCategoryName('');
            setSelectedCategoryId(''); 
            fetchSubCategories(); 
        } catch (error) {
            console.error('Error in adding new SubCategory', error);
        }
    };

    const deleteSubCategory = async (id) => {
        try {
            await SubCategoryService.deleteSubCategory(id);
            fetchSubCategories();
        } catch (error) {
            console.error('Error in deleting SubCategory', error);
        }
    };

    const handleEdit = (subcategory) => {
        setEditingSubCategory(subcategory);
        setEditSubCategoryName(subcategory.subcategoryName);
        setSelectedCategoryId(subcategory.categoryId); 
    };

    const handleUpdate = async (e) => {
        e.preventDefault();
        if (editingSubCategory) {
            const updatedSubCategory = {
                subcategoryName: editSubCategoryName,
                categoryId: selectedCategoryId, 
            };
            try {
                await SubCategoryService.updateSubCategory(editingSubCategory.subcategoryId, updatedSubCategory);
                setEditingSubCategory(null);
                setEditSubCategoryName('');
                setSelectedCategoryId(''); 
                fetchSubCategories(); 
            } catch (error) {
                console.error('Error in updating SubCategory:', error);
            }
        }
    };

    const getCategoryNameById = (categoryId) => {
        const category = categories.find(cat => cat.categoryId === categoryId);
        return category ? category.categoryName : 'No Category';
    };

    return (
        <div className="p-8">
             <div className="addSubCategoryForm bg-white p-4 rounded shadow">
                <h3 className="text-xl font-semibold mb-4">{editingSubCategory ? 'Update SubCategory' : 'Add New SubCategory'}</h3>
                <form onSubmit={editingSubCategory ? handleUpdate : addNewSubCategory}>
                    <div className="mb-4">
                        <label htmlFor="subcategoryName" className="block text-gray-700 mb-2">Sub-category Name:</label>
                        <input
                            type="text"
                            id="subcategoryName"
                            value={editingSubCategory ? editSubCategoryName : newSubCategoryName}
                            onChange={(e) => editingSubCategory ? setEditSubCategoryName(e.target.value) : setNewSubCategoryName(e.target.value)}
                            required
                            className="border border-gray-300 p-2 w-full rounded"
                        />
                    </div>
                    <div className="mb-4">
                        <label htmlFor="category" className="block text-gray-700 mb-2">Select Category:</label>
                        <select
                            id="category"
                            value={selectedCategoryId}
                            onChange={(e) => setSelectedCategoryId(e.target.value)}
                            required
                            className="border border-gray-300 p-2 w-full rounded"
                        >
                            <option value="" disabled>Select a category</option>
                            {categories.map(category => (
                                <option key={category.categoryId} value={category.categoryId}>
                                    {category.categoryName}
                                </option>
                            ))}
                        </select>
                    </div>
                    <button 
                        type='submit' 
                        className="bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600"
                    >
                        {editingSubCategory ? 'Update' : 'Create'}
                    </button>
                </form>
            </div>
            <div className="showsubcategories mb-6 bg-white p-4 rounded shadow">
                <h1 className="text-2xl font-bold mb-4">SubCategories List</h1>
                <table className="min-w-full border border-gray-300">
                    <thead>
                        <tr className="bg-gray-200">
                            <th className="px-4 py-2 text-left">Sub-category Name</th>
                            <th className="px-4 py-2 text-left">Category Name</th>
                            <th className="px-4 py-2 text-left">Action Buttons</th>
                        </tr>
                    </thead>
                    <tbody>
                        {subcategories.map(subcategory => (
                            <tr key={subcategory.subcategoryId} className="border-b">
                                <td className="px-4 py-2">{subcategory.subcategoryName}</td>
                                <td className="px-4 py-2">{getCategoryNameById(subcategory.categoryId)}</td>
                                <td className="px-4 py-2">
                                    <button 
                                        onClick={() => handleEdit(subcategory)} 
                                        className="bg-blue-500 text-white px-2 py-1 rounded mr-2 hover:bg-blue-600"
                                    >
                                        Edit
                                    </button>
                                    <button 
                                        onClick={() => deleteSubCategory(subcategory.subcategoryId)} 
                                        className="bg-red-500 text-white px-2 py-1 rounded hover:bg-red-600"
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

export default SubCategoryComponent;
