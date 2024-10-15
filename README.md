Here's an updated version of the `README.md` file that includes your recent additions:

---

# .NET Core Web API Project with SQL Server

This project is a .NET Core Web API using a SQL Server database (`seconddb`). It implements CRUD operations for various entities such as brands, categories, subcategories, sizes, and colors. The project also includes advanced functionality for products, with support for multiple sizes, colors, and image uploads, alongside many-to-many relationships for product sizes and colors.

Additionally, the project includes a one-to-many relationship for managing multiple images associated with products and an endpoint to retrieve subcategories by category.

## Technologies Used

- .NET Core Web API
- SQL Server
- Entity Framework Core
- Vite (for the frontend)
- Axios (for API calls)

## Features

1. **CRUD Operations**:
   - **Brand**: Create, Read, Update, Delete brands.
   - **Category**: Create, Read, Update, Delete categories.
   - **Subcategory**: Create, Read, Update, Delete subcategories, with a new endpoint to find subcategories by category.
   - **Size**: Create, Read, Update, Delete sizes.
   - **Color**: Create, Read, Update, Delete colors.

2. **Product Management**:
   - **Product CRUD**: Manage products with support for:
     - **Multiple Sizes**: A product can have many sizes (many-to-many relationship).
     - **Multiple Colors**: A product can have many colors (many-to-many relationship).
     - **Multiple Images**: A one-to-many relationship for managing multiple images per product.
     - **Image Upload**: Upload multiple images for a product.

3. **Database Relationships**:
   - **Many-to-Many Relationships**:
     - Products and Sizes.
     - Products and Colors.
   - **One-to-Many Relationships**:
     - Products to Categories.
     - Products to Subcategories.
     - Products to Brands.
     - Products to Images (new feature for managing multiple images).

4. **New API Endpoints**:
   - **Find Subcategories by Category**: Retrieve subcategories for a specific category using the endpoint `api/subcategory/getbycategory/{id}`.

## Setup Instructions

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/Diranujan/task-01-dot-net-core-web-api.git
   cd your-repo-folder
   ```

2. **SQL Server Setup**:
   - Create a new SQL Server database named `seconddb`.
   - Update the connection string in `appsettings.json`:
     ```json
     "ConnectionStrings": {
            "DefaultConnection": "Data Source={{YOUR PC Name }}\\SQLEXPRESS;Initial Catalog=seconddb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"

     }
     - change database name if you want.
     ```

3. **Database Migration**:
    
   - Run the following command to apply the database migrations:
     ```bash
     dotnet ef database update
     ```

4. **Run the API**:
   - Navigate to the backend project directory and run:
     ```bash
     dotnet watch run
     ```

5. **Frontend Setup (if applicable)**:
   - Navigate to the frontend directory (React + Vite) and run:
     ```bash
     npm install
     npm run dev
     ```


### Brand Endpoints
- `GET /api/brand`
- `GET /api/brand/{id}` 
- `POST /api/brand`
- `PUT /api/brand/{id}`
- `DELETE /api/brand/{id}`

### Category Endpoints
- `GET /api/category`
- `GET /api/category/{id}` 
- `POST /api/category`
- `PUT /api/category/{id}`
- `DELETE /api/category/{id}`

### Subcategory Endpoints
- `GET /api/subcategory`
- `GET /api/subcategory/{id}` 
- `POST /api/subcategory`
- `PUT /api/subcategory/{id}`
- `DELETE /api/subcategory/{id}`
- `GET /api/subcategory/getbycategory/{id}` 

### Size Endpoints
- `GET /api/size`
- `GET /api/size/{id}`
- `POST /api/size`
- `PUT /api/size/{id}`
- `DELETE /api/size/{id}`

### Color Endpoints
- `GET /api/color`
- `GET /api/color/{id}` 
- `POST /api/color`
- `PUT /api/color/{id}`
- `DELETE /api/color/{id}`

### Product Endpoints
- `GET /api/product`
- `GET /api/product/{id}` 
- `POST /api/product`
- `PUT /api/product/{id}`
- `DELETE /api/product/{id}`



Let me know if you'd like any other adjustments!
Supports adding multiple sizes, colors, and images for each product.

### Image Endpoints
- Manage multiple images for a product using the `Product` CRUD methods with image upload functionality.

## Notes

- The project uses **Entity Framework Core** for data access.
- Image uploads are stored locally, and their file paths are saved in the database.
- Ensure that SQL Server is running and accessible from the connection string provided.


## Contact

For any questions, suggestions, or issues, please feel free to reach out:

- **Name**: Diranujan
- **Email**: diranujan2000@gmail.com


This project is licensed under the MIT License.
