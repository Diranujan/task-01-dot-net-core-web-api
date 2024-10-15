import { useEffect, useState } from "react";
import BrandService from '../services/BrandService';

const BrandComponent = () => {
  const [brands, setBrands] = useState([]);
  const [newBrandName, setNewBrandName] = useState('');
  const [newBrandDescription, setNewBrandDescription] = useState('');
  const [editingBrand, setEditingBrand] = useState(null);
  const [editBrandName, setEditBrandName] = useState('');
  const [editBrandDescription, setEditBrandDescription] = useState('');

  useEffect(() => {
    fetchBrands();
  }, []);

  const fetchBrands = async () => {
    try {
        const response = await BrandService.getAllBrands(); 
        setBrands(response.data);
    } catch (error) {
        console.error('Error in fetching Brand Data', error);
    }
  };

  const addNewBrand = async (e) => {
    e.preventDefault();

    const newBrand = {
        brandName: newBrandName, 
        brandDescription: newBrandDescription, 
    };
    try {
        await BrandService.createBrand(newBrand);
        setNewBrandName('');
        setNewBrandDescription('');
        fetchBrands();
    } catch (error) {
        console.error('Error in adding new brand', error);
    }
  };

  const deleteBrand = async (id) => {
    try {
        await BrandService.deleteBrand(id);
      fetchBrands();
    } catch (error) {
        console.error('Error in deleting brand', error);
    }
  };

  const handleEdit = (brand) => {
      setEditingBrand(brand);
      setEditBrandName(brand.brandName);
      setEditBrandDescription(brand.brandDescription);
  };

  const handleUpdate = async (e) => {
    e.preventDefault();
    if (editingBrand) {
      const updatedBrand = {
          brandName: editBrandName,
          brandDescription: editBrandDescription,
      };
      try {
          await BrandService.updateBrand(editingBrand.brandId, updatedBrand); 
          setEditingBrand(null);
          setEditBrandName('');
          setEditBrandDescription('');
          fetchBrands();
      } catch (error) {
          console.error('Error in updating brand:', error);
      }
    }
  };

  return (
    <div>
      <div className="addbrandForm p-3 mt-3 bg-white shadow-md rounded-lg">
        <h3 className="text-l font-semibold mb-4">
          {editingBrand ? 'Update Brand' : 'Add New Brand'}
        </h3>
        <form onSubmit={editingBrand ? handleUpdate : addNewBrand} className="space-y-4">
          <div>
            <label htmlFor="brandName" className="block mb-2 font-medium">
              Brand Name:
            </label>
            <input
              type="text"
              id="brandName"
              className="w-full px-2 py-1 border border-gray-300 rounded-md"
              value={editingBrand ? editBrandName : newBrandName}
              onChange={(e) =>
                editingBrand ? setEditBrandName(e.target.value) : setNewBrandName(e.target.value)
              }
              required
            />
          </div>
          <div>
            <label htmlFor="brandDescription" className="block mb-2 font-medium">
              Brand Description:
            </label>
            <input
              type="text"
              id="brandDescription"
              className="w-full px-2 py-1 border border-gray-300 rounded-md"
              value={editingBrand ? editBrandDescription : newBrandDescription}
              onChange={(e) =>
                editingBrand
                  ? setEditBrandDescription(e.target.value)
                  : setNewBrandDescription(e.target.value)
              }
            />
          </div>
          <button
            type="submit"
            className={`${
              editingBrand ? 'bg-yellow-500 hover:bg-yellow-600' : 'bg-green-500 hover:bg-green-600'
            } text-white py-2 px-4 rounded-md transition`}
          >
            {editingBrand ? 'Update' : 'Create'}
          </button>
        </form>
      </div>
      <div className="showbrands p-5">
        <h1 className="text-2xl font-bold mb-4">Brands List</h1>
        <table className="min-w-full bg-white border border-gray-300">
          <thead>
            <tr className="bg-gray-100">
              <th className="py-2 px-4 border-b text-left">Brand Name</th>
              <th className="py-2 px-4 border-b text-left">Brand Description</th>
              <th className="py-2 px-4 border-b text-left">Action Buttons</th>
            </tr>
          </thead>
          <tbody>
            {brands.map((brand) => (
              <tr key={brand.brandId} className="hover:bg-gray-50">
                <td className="py-2 px-4 border-b">{brand.brandName}</td>
                <td className="py-2 px-4 border-b">{brand.brandDescription}</td>
                <td className="py-2 px-4 border-b">
                  <button
                    className="bg-blue-500 text-white py-1 px-3 rounded-md hover:bg-blue-600 transition"
                    onClick={() => handleEdit(brand)}
                  >
                    Edit
                  </button>
                  <button
                    className="bg-red-500 text-white py-1 px-3 ml-2 rounded-md hover:bg-red-600 transition"
                    onClick={() => deleteBrand(brand.brandId)}
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

export default BrandComponent;
