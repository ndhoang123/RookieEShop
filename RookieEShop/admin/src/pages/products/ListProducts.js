import React from 'react';
import { Table, Button } from 'reactstrap';
import ProductService from './products';
import { Link } from 'react-router-dom';
import ProductImage from 'E:/Coding/RookieEShop/admin/src/components/ProductImage';

const ListProduct = () => {
    const [Products, setProducts] = React.useState([]);

    React.useEffect(() => {
        fetchCategory();
    }, []);

    const fetchCategory = () => {
        ProductService.getList().then(({ data }) => setProducts(data));
        console.log(Products);
    };

    const handleDelete = (itemId) => {
        let result = window.confirm("Delete this category?");
        if (result) {
            ProductService.delete(itemId).then(() => {
            setProducts(Products.filter((item) => item.id !== itemId));
          });
        }
      };


    return (
        
        <Table>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Name</th>
                    <th>Image</th>
                    <th>Price</th>
                    <th>Author</th>
                    <th>Year</th>
                    <th>Publisher</th>
                    <th>Description</th>
                    <td className="text-right">
                        <Link to={"/NewProduct"} class="btn btn-primary">Create</Link>
                    </td>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {Products.map(function (item, i) {
                return (
                    <tr>
                        <th scope="row">{i}</th>
                        <td>{item.name}</td>
                        <ProductImage src={item.thumbnailImageUrl} item={item}/>
                        <td>{item.price}</td>
                        <td>{item.author}</td>
                        <td>{item.year}</td>
                        <td>{item.publisher}</td>
                        <td>{item.description}</td>
                        <td className="text-right">
                            <Link to={`/EditProduct/${item.id}`} class="btn btn-primary">Edit</Link>{' '}
                            <Button onClick={() => handleDelete(item.id)} color="danger"> Delete</Button>
                        </td>
                    </tr>
                    );
                })}
            </tbody>
        </Table>
    );
}

export default ListProduct;
