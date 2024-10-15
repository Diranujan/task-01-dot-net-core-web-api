import axios from 'axios';

const API_URL = 'https://localhost:7281/api/size'; 

const ColorService = {
    getAllSizes: () => axios.get(API_URL),
    createSize: (size) => axios.post(API_URL, size),
    updateSize: (id, size) => axios.put(`${API_URL}/${id}`, size),
    deleteSize: (id) => axios.delete(`${API_URL}/${id}`),
};


export default ColorService;
