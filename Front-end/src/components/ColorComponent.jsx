import { useEffect, useState } from "react";
import ColorService from "../services/ColorService";

const ColorComponent = () => {
    const [colors, setColors] = useState([]);
    const [newColorName, setNewColorName] = useState('');
    const [editingColor, setEditingColor] = useState(null);
    const [editColorName, setEditColorName] = useState('');

    useEffect(() => {
        fetchColors();
    }, []);

    const fetchColors = async () => {
        try {
            const response = await ColorService.getAllColors(); // Ensure the ColorService method matches
            setColors(response.data); // Adjust this if the structure of response is different
        } catch (error) {
            console.error('Error in fetching Color Data', error);
        }
    };

    const addNewColor = async (e) => {
        e.preventDefault();

        const newColor = {
            colorName: newColorName,
        };
        try {
            await ColorService.createColor(newColor);
            setNewColorName('');
            fetchColors();
        } catch (error) {
            console.error('Error in adding new color', error);
        }
    };

    const deleteColor = async (id) => {
        try {
            await ColorService.deleteColor(id);
            fetchColors();
        } catch (error) {
            console.error('Error in deleting Color', error);
        }
    };

    const handleEdit = (color) => {
        setEditingColor(color);
        setEditColorName(color.colorName);
    };

    const handleUpdate = async (e) => {
        e.preventDefault();
        if (editingColor) {
            const updatedColor = {
                colorName: editColorName,
            };
            try {
                await ColorService.updateColor(editingColor.colorId, updatedColor); // Ensure the colorId matches your model
                setEditingColor(null);
                setEditColorName('');
                fetchColors();
            } catch (error) {
                console.error('Error in updating color:', error);
            }
        }
    };

    return (
        <div className="p-8 ">
            <div className="w-full addcolorForm bg-white p-4 rounded shadow">
                <h3 className="text-xl font-semibold mb-4">{editingColor ? 'Update Color' : 'Add New Color'}</h3>
                <form onSubmit={editingColor ? handleUpdate : addNewColor}>
                    <div className="mb-4">
                        <label htmlFor="colorName" className="block text-gray-700 mb-2">Color Name:</label>
                        <input
                            type="text"
                            id="colorName"
                            value={editingColor ? editColorName : newColorName}
                            onChange={(e) => editingColor ? setEditColorName(e.target.value) : setNewColorName(e.target.value)}
                            required
                            className="border border-gray-300 p-2 w-full rounded"
                        />
                    </div>
                    <button 
                        type='submit' 
                        className="bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600"
                    >
                        {editingColor ? 'Update' : 'Create'}
                    </button>
                </form>
            </div>
            <div className="w-full showcolors mb-6">
                <h1 className="text-2xl font-bold mb-4">Colors List</h1>
                <table className="min-w-full border border-gray-300">
                    <thead>
                        <tr className="bg-gray-200">
                            <th className="px-4 py-2 text-left">Color Name</th>
                            <th className="px-4 py-2 text-left">Action Buttons</th>
                        </tr>
                    </thead>
                    <tbody>
                        {colors.map(color => (
                            <tr key={color.colorId} className="border-b">
                                <td className="px-4 py-2">{color.colorName}</td>
                                <td className="px-4 py-2">
                                    <button 
                                        onClick={() => handleEdit(color)} 
                                        className="bg-blue-500 text-white px-2 py-1 rounded mr-2 hover:bg-blue-600"
                                    >
                                        Edit
                                    </button>
                                    <button 
                                        onClick={() => deleteColor(color.colorId)} 
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

export default ColorComponent;
