import axios from 'axios';

const API_URL = 'https://localhost:7281/api/brand'; 

const BrandService = {
    getAllBrands: () => axios.get(API_URL),
    createBrand: (brand) => axios.post(API_URL, brand),
    updateBrand: (id, brand) => axios.put(`${API_URL}/${id}`, brand),
    deleteBrand: (id) => axios.delete(`${API_URL}/${id}`),
};

export default BrandService;
