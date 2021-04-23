import React from 'react';
import { Table, Button } from 'reactstrap';
import CategoryService from './categories';
import { Link } from 'react-router-dom';
import EditCategory from "./EditCategories";

const ListCategories = () => {
    const [Categories, setCategories] = React.useState([]);
    React.useEffect(() => {
        fetchCategory();
    }, []);

    const fetchCategory = () => {
        CategoryService.getList().then(({ data }) => setCategories(data));
    };

    const handleDelete = (itemId) => {
        let result = window.confirm("Delete this category?");
        if (result) {
          CategoryService.delete(itemId).then(() => {
            setCategories(Categories.filter((item) => item.id !== itemId));
          });
        }
      };

    return (
        <div>
            <Table>
                <thead>
                    <tr>
                        <th>STT</th>
                        <th>Category Name</th>
                        <td className="text-right">
                            <Button color="primary">Create</Button>
                        </td>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {Categories.map(function (item, i) {
                        return (
                            <tr>
                                <th scope="row">{i}</th>
                                <td>{item.name}</td>
                                <td className="text-right">
                                    <Link to={`/EditCategory/${item.id}`} class="btn btn-primary">Edit</Link>{' '}
                                    <Button onClick={() => handleDelete(item.id)} color="danger"> Delete</Button>
                                </td>
                            </tr>
                            );
                        })}
                </tbody>
            </Table>
        </div>
    );
}
export default ListCategories;
