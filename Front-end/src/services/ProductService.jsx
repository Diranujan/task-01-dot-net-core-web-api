import axios from 'axios';

const API_URL = 'https://localhost:7281/api/Product'; 

const ProductService = {
    getAllProducts: () => axios.get(API_URL),
    createProduct: (product) => axios.post(API_URL, product),
    updateProduct: (id, Product) => axios.put(`${API_URL}/${id}`, Product),
    deleteProduct: (id) => axios.delete(`${API_URL}/${id}`),
};


export default ProductService;
