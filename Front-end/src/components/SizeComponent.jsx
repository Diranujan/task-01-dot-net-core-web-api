import { useEffect, useState } from "react";
import SizeService from "../services/SizeService";

const SizeComponent = () => {
    const [sizes, setSizes] = useState([]);
    const [newSizeName, setNewSizeName] = useState('');
    const [editingSize, setEditingSize] = useState(null);
    const [editSizeName, setEditSizeName] = useState('');

    useEffect(() => {
        fetchSizes();
    }, []);

    const fetchSizes = async () => {
        try {
            const response = await SizeService.getAllSizes(); 
            setSizes(response.data); 
        } catch (error) {
            console.error('Error in fetching Size Data', error);
        }
    };

    const addNewSize = async (e) => {
        e.preventDefault();

        const newSize = {
            sizeName: newSizeName,
        };
        try {
            await SizeService.createSize(newSize);
            setNewSizeName('');
            fetchSizes();
        } catch (error) {
            console.error('Error in adding new size', error);
        }
    };

    const deleteSize = async (id) => {
        try {
            await SizeService.deleteSize(id);
            fetchSizes();
        } catch (error) {
            console.error('Error in deleting Size', error);
        }
    };

    const handleEdit = (size) => {
        setEditingSize(size);
        setEditSizeName(size.sizeName);
    };

    const handleUpdate = async (e) => {
        e.preventDefault();
        if (editingSize) {
            const updatedSize = {
                sizeName: editSizeName,
            };
            try {
                await SizeService.updateSize(editingSize.sizeId, updatedSize); 
                setEditingSize(null);
                setEditSizeName('');
                fetchSizes();
            } catch (error) {
                console.error('Error in updating size:', error);
            }
        }
    };

    return (
        <div className="p-8">
            <div className="addsizeForm bg-white p-4 rounded shadow">
                <h3 className="text-xl font-semibold mb-4">{editingSize ? 'Update Size' : 'Add New Size'}</h3>
                <form onSubmit={editingSize ? handleUpdate : addNewSize}>
                    <div className="mb-4">
                        <label htmlFor="sizeName" className="block text-gray-700 mb-2">Size Name:</label>
                        <input
                            type="text"
                            id="sizeName"
                            value={editingSize ? editSizeName : newSizeName}
                            onChange={(e) => editingSize ? setEditSizeName(e.target.value) : setNewSizeName(e.target.value)}
                            required
                            className="border border-gray-300 p-2 w-full rounded"
                        />
                    </div>
                    <button 
                        type='submit' 
                        className="bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600"
                    >
                        {editingSize ? 'Update' : 'Create'}
                    </button>
                </form>
            </div>
            <div className="showsizes mb-6 bg-white p-4 rounded shadow">
                <h1 className="text-2xl font-bold mb-4">Sizes List</h1>
                <table className="min-w-full border border-gray-300">
                    <thead>
                        <tr className="bg-gray-200">
                            <th className="px-4 py-2 text-left">Size Name</th>
                            <th className="px-4 py-2 text-left">Action Buttons</th>
                        </tr>
                    </thead>
                    <tbody>
                        {sizes.map(size => (
                            <tr key={size.sizeId} className="border-b">
                                <td className="px-4 py-2">{size.sizeName}</td>
                                <td className="px-4 py-2">
                                    <button 
                                        onClick={() => handleEdit(size)} 
                                        className="bg-blue-500 text-white px-2 py-1 rounded mr-2 hover:bg-blue-600"
                                    >
                                        Edit
                                    </button>
                                    <button 
                                        onClick={() => deleteSize(size.sizeId)} 
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

export default SizeComponent;
