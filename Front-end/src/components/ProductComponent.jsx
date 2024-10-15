import { useState, useEffect } from "react";
import ProductService from "../services/ProductService";
import CategoryService from "../services/CategoryService";
import SubCategoryService from "../services/SubCategoryService";
import BrandService from '../services/BrandService';
import ColorService from "../services/ColorService";
import SizeService from "../services/SizeService";

const ProductComponent = () => {
    const [products, setProducts] = useState([]);
    const [categories, setCategories] = useState([]);
    const [subCategories, setSubCategories] = useState([]);
    const [brands, setBrands] = useState([]);
    const [colors, setColors] = useState([]);
    const [sizes, setSizes] = useState([]);
    const [currentImageIndex, setCurrentImageIndex] = useState({}); // State to track current image index for each product

    useEffect(() => {
        fetchProducts();
        fetchCategories();
        fetchSubCategories();
        fetchBrands();
        fetchColors();
        fetchSizes();
    }, []);

    const fetchProducts = async () => {
        try {
            const response = await ProductService.getAllProducts();
            setProducts(response.data);
            const initialImageIndex = {};
            response.data.forEach(product => {
                initialImageIndex[product.productId] = 0; // Set initial image index to 0 for each product
            });
            setCurrentImageIndex(initialImageIndex);
        } catch (error) {
            console.error('Error fetching products', error);
        }
    };

    const fetchCategories = async () => {
        try {
            const response = await CategoryService.getAllCategories();
            setCategories(response.data);
        } catch (error) {
            console.error('Error fetching categories', error);
        }
    };

    const fetchSubCategories = async () => {
        try {
            const response = await SubCategoryService.getAllSubCategories();
            setSubCategories(response.data);
        } catch (error) {
            console.error('Error fetching subcategories', error);
        }
    };

    const fetchBrands = async () => {
        try {
            const response = await BrandService.getAllBrands();
            setBrands(response.data);
        } catch (error) {
            console.error('Error fetching brands', error);
        }
    };

    const fetchColors = async () => {
        try {
            const response = await ColorService.getAllColors();
            setColors(response.data);
        } catch (error) {
            console.error('Error fetching colors', error);
        }
    };

    const fetchSizes = async () => {
        try {
            const response = await SizeService.getAllSizes();
            setSizes(response.data);
        } catch (error) {
            console.error('Error fetching sizes', error);
        }
    };

    const getCategoryNameById = (categoryId) => {
        const category = categories.find(cat => cat.categoryId === categoryId);
        return category ? category.categoryName : 'No Category';
    };

    const getSubCategoryNameById = (subcategoryId) => {
        const subcategory = subCategories.find(i => i.subcategoryId === subcategoryId);
        return subcategory ? subcategory.subcategoryName : 'No SubCategory';
    };

    const getBrandNameById = (brandId) => {
        const brand = brands.find(i => i.brandId === brandId);
        return brand ? brand.brandName : 'No Brand';
    };

    const getColorNameById = (colorId) => {
        const color = colors.find(i => i.colorId === colorId);
        return color ? color.colorName : 'No Color';
    };

    const getSizeById = (sizeId) => {
        const size = sizes.find(i => i.sizeId === sizeId);
        return size ? size.sizeName : 'No Size';
    };

    const nextImage = (productId, product) => {
        setCurrentImageIndex((prevState) => ({
            ...prevState,
            [productId]: prevState[productId] === product.images.length - 1 ? 0 : prevState[productId] + 1,
        }));
    };

    const prevImage = (productId, product) => {
        setCurrentImageIndex((prevState) => ({
            ...prevState,
            [productId]: prevState[productId] === 0 ? product.images.length - 1 : prevState[productId] - 1,
        }));
    };

    return (
        <div className="product-list mt-5">
            {products.map((product) => (
                <div className="product-card container mx-auto" key={product.productId}>
                    <div className="grid grid-cols-2 gap-2 w-full">
                        <div className="p-4 justify-center  align-middle  ">
                            <h3 className="product-name"><strong>Name :</strong>{product.productName}</h3>
                            <p className="product-description"><strong>Description :</strong>{product.productDescription}</p> 
                            <p><strong>Category :</strong> {getCategoryNameById(product.categoryId)}</p>
                            <p><strong>Subcategory :</strong> {getSubCategoryNameById(product.subcategoryId)}</p>
                            <p><strong>Brand :</strong> {getBrandNameById(product.brandId)}</p>
                            <p><strong>Product Colors:</strong></p>
                                {product.productColors.length > 0 ? (
                                    product.productColors.map((color) => (
                                        <span key={color.colorId} className="pr-2">
                                            {getColorNameById(color.colorId)}
                                        </span>
                                    ))
                                ) : (
                                    <p>No colors available</p>
                                )}
                            <p><strong>Product Sizes:</strong></p>
                                {product.productSizes.length > 0 ? (
                                    product.productSizes.map((size) => (
                                        <span key={size.sizeId} className="pr-2">
                                            {getSizeById(size.sizeId)}
                                        </span>
                                    ))
                                ) : (
                                    <p>No sizes available</p>
                                )}
                        </div>
                        <div className="p-4">
                            {product.images.length > 0 ? (
                                <div className="relative w-full">
                                    <img
                                        src={`https://localhost:7281/${product.images[currentImageIndex[product.productId]].imagePath}`}
                                        alt={`Product Image ${product.images[currentImageIndex[product.productId]].imageId}`}
                                        className="block w-full h-auto"
                                    />
                                    {/* Previous Button */}
                                    <button
                                        onClick={() => prevImage(product.productId, product)}
                                        className="absolute top-1/2 left-0 transform -translate-y-1/2 bg-gray-600 text-white p-2"
                                    >
                                        Prev
                                    </button>

                                    {/* Next Button */}
                                    <button
                                        onClick={() => nextImage(product.productId, product)}
                                        className="absolute top-1/2 right-0 transform -translate-y-1/2 bg-gray-600 text-white p-2"
                                    >
                                        Next
                                    </button>
                                </div>
                            ) : (
                                <p>No images available</p>
                            )}
                        </div>
                    </div>
                </div>
            ))}
        </div>
    );
};

export default ProductComponent;
