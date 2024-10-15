import axios from 'axios';

const API_URL = 'https://localhost:7281/api/category'; 

const CategoryService = {
    getAllCategories: () => axios.get(API_URL),
    createCategory: (category) => axios.post(API_URL, category),
    updateCategory: (id, category) => axios.put(`${API_URL}/${id}`, category),
    deleteCategory: (id) => axios.delete(`${API_URL}/${id}`),
};


export default CategoryService;
