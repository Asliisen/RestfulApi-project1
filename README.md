# RestfulApi-project1
# Product Management RESTful API

This project provides a RESTful API that can be used to perform basic operations such as adding, updating, listing and deleting products. It also includes the ability to list and sort products.

## API Endpoints

- To list all products: `GET /api/products`
- To get a specific product by ID: `GET /api/products/{id}`
- To add a new product: `POST /api/products`
- To update a product: `PUT /api/products/{id}`
- To delete a product: `DELETE /api/products/{id}`
- To filter and sort products by name: `GET /api/products/list?name={name}`
