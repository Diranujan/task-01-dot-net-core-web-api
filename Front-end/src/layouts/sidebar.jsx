import React from 'react';
import { Link } from 'react-router-dom';

const Sidebar = () => {
  return (
    <div className="sidebar bg-gray-900 text-white w-64 h-full fixed top-0 left-0 p-4">
        <ul className="space-y-4">
            <li className="hover:bg-gray-700 transition-colors duration-300 rounded-md p-2">
            <Link to="/">Home</Link>
            </li>
            <li className="hover:bg-gray-700 transition-colors duration-300 rounded-md p-2">
            <Link to="/category">Category</Link>
            </li>
            <li className="hover:bg-gray-700 transition-colors duration-300 rounded-md p-2">
            <Link to="/subcategory">Sub-Category</Link>
            </li>
            <li className="hover:bg-gray-700 transition-colors duration-300 rounded-md p-2">
            <Link to="/brand">Brand</Link>
            </li>
            <li className="hover:bg-gray-700 transition-colors duration-300 rounded-md p-2">
            <Link to="/color">Color</Link>
            </li>
            <li className="hover:bg-gray-700 transition-colors duration-300 rounded-md p-2">
            <Link to="/size">Size</Link>
            </li>
        </ul>
    </div>

  );
};

export default Sidebar;
