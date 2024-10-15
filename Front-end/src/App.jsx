import React, { useState } from 'react';
import { Routes, Route } from 'react-router-dom';
import Home from './pages/Home';
import About from './pages/About';
import Category from './pages/Category';
import SubCategory from './pages/SubCategory';
import Brand from './pages/Brand';
import Color from './pages/Color';
import Size from './pages/Size';
import Sidebar from './layouts/sidebar';  

function App() {
  const [isSidebarOpen, setIsSidebarOpen] = useState(true);

  const toggleSidebar = () => {
    setIsSidebarOpen(!isSidebarOpen);
  };

  return (
    <div className="app-container mt-5">
      <button className={`sidebar-toggle ${   isSidebarOpen ? 'bg-green-500 text-white' : 'bg-gray-300 text-gray-800' } px-4 py-2 rounded transition duration-300 ease-in-out`} onClick={toggleSidebar} >
          {isSidebarOpen ? 'Close' : 'Menu'}
      </button>
      <div className={`sidebar ${  isSidebarOpen ? 'translate-x-0' : '-translate-x-full' } fixed top-0 left-0 h-full w-64 bg-white shadow-lg transition-transform duration-300 ease-in-out`}>
          <Sidebar />
      </div>

      <div className="content flex justify-center align-center">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/about" element={<About />} />
          <Route path="/category" element={<Category />} />
          <Route path="/subcategory" element={<SubCategory />} />
          <Route path="/brand" element={<Brand />} />
          <Route path="/color" element={<Color />} />
          <Route path="/size" element={<Size />} />
        </Routes>
      </div>
    </div>
  );
}

export default App;
