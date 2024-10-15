import axios from 'axios';

const API_URL = 'https://localhost:7281/api/subcategory'; 

const SubCategoryService = {
    getAllSubCategories: () => axios.get(API_URL),
    createSubCategory: (subcategory) => axios.post(API_URL, subcategory),
    updateSubCategory: (id, subcategory) => axios.put(`${API_URL}/${id}`, subcategory),
    deleteSubCategory: (id) => axios.delete(`${API_URL}/${id}`),
    getByCategory: (id) => axios.get(`${API_URL}/getbycatgory/${id}`) 
};



export default SubCategoryService;
