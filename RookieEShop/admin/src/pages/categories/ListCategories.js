import React from 'react';
import { Table, Button, NavLink } from 'reactstrap';
import CategoryService from './categories'

const ListCategories = () => {
    const [Categories, setCategories] = React.useState([]);
    React.useEffect(() => {
        fetchCategory();
    }, []);

    const fetchCategory = () => {
        CategoryService.getList().then(({ data }) => setCategories(data));
    };

    return (
        <div>
            <Table>
                <thead>
                    <tr>
                        <th>STT</th>
                        <th>Category Name</th>
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
                                    <Button color="link"> Edit</Button>
                                    <Button
                                    color="link"
                                    className="text-danger"
                                    > Remove
                                    </Button>
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
