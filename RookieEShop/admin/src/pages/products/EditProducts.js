import React, { useState, useEffect } from 'react';
import { Col, Button, Form, FormGroup, Label, Input, InputGroup  } from 'reactstrap';
import { useFormik } from "formik";
import products from './products';
import { withRouter } from "react-router-dom";
import history from '../../helpers/history';

const EditProducts = ({ match }) => {
    const [categoryItems, setCategoryItem] = useState([]);

    const [product, setProduct] = useState(null);

    const [productId, setProductId] = useState(match.params.id);

    useEffect(() => {

        if (product) {
            alert('successful');
        }

    }, [product]);

    const formik = useFormik({
        initialValues: {
            name: '',
            price: 0,
            author: '',
            year: 0,
            descripion: '',
            publisher: '',
            ThumbnailImage: null,
            categoryId: '',
        },
        
        onSubmit: async (values, action) => {
            values = {
                ...values,
                categoryId: Number(values.categoryId),
            };

            action.setSubmitting(true);
            console.log(values);

            var formData = new FormData();

            Object.keys(values).forEach(key => {
                formData.append(key, values[key])
            });

            let result = window.confirm("Are you sure?");
            if(result) {
                let isCreate = productId === undefined ? true : false;

                    if(isCreate){
                        await products.create(formData);
                        history.goBack();
                    }

                    else {
                        await products.edit(productId, values);
                        history.goBack();
                    }
            }
        }
    })

    return (
        <Form onSubmit={formik.handleSubmit}>
            <FormGroup row>
                <Label for="Name" sm={2}>Name</Label>
                <Col sm={10}>
                    <Input type="text" name="name" onChange={formik.handleChange} 
                    value={formik.values.name}/>
                </Col>
            </FormGroup>

            <FormGroup row>
                <Label for="Price" sm={2}>Price</Label>
                <Col sm={10}>
                    <Input type="number" name="price" onChange={formik.handleChange} 
                    value={formik.values.price}/>
                </Col>
            </FormGroup>

            <FormGroup row>
                <Label for="Author" sm={2}>Author</Label>
                <Col sm={10}>
                    <Input type="text" name="author" onChange={formik.handleChange} 
                    value={formik.values.author}/>
                </Col>
            </FormGroup>

            <FormGroup row>
                <Label for="Year" sm={2}>Year</Label>
                <Col sm={10}>
                    <Input type="number" name="year" onChange={formik.handleChange} 
                    value={formik.values.year}/>
                </Col>
            </FormGroup>

            <FormGroup row>
                <Label for="Description" sm={2}>Description</Label>
                <Col sm={10}>
                    <Input type="text" name="description" onChange={formik.handleChange} 
                    value={formik.values.description}/>
                </Col>
            </FormGroup>

            <FormGroup row>
                <Label for="Publisher" sm={2}>Publisher</Label>
                <Col sm={10}>
                    <Input type="text" name="publisher" onChange={formik.handleChange} 
                    value={formik.values.publisher}/>
                </Col>
            </FormGroup>

            <FormGroup row>
                <Label for="CategoryId" sm={2}>CategoryId</Label>
                <Col sm={10}>
                    <Input type="number" name="categoryId" onChange={formik.handleChange} />
                </Col>
            </FormGroup>

            <InputGroup>
                    <input name="ProductImg" type="file" onChange={(event) => {
                        formik.setFieldValue("ThumbnailImage", event.currentTarget.files[0]);
                    }} />
            </InputGroup>

            <FormGroup check row>
                <Col sm={{ size: 10, offset: 2 }}>
                    <Button>Submit</Button>
                </Col>
            </FormGroup>
        </Form>
      );
    
}

export default withRouter(EditProducts);