import axios from 'axios';

const API_URL = 'https://localhost:7281/api/color'; 

const ColorService = {
    getAllColors: () => axios.get(API_URL),
    createColor: (color) => axios.post(API_URL, color),
    updateColor: (id, color) => axios.put(`${API_URL}/${id}`, color),
    deleteColor: (id) => axios.delete(`${API_URL}/${id}`),
};


export default ColorService;
