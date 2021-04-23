import React, { useState, useEffect } from 'react';
import { Form, Label, Input } from 'reactstrap';
import { useFormik } from "formik";
import categories from './categories';
import { withRouter } from "react-router-dom";
import history from '../../helpers/history';

const EditCategories = ({ match }) => {

  const [categoryId, setCategoryId] = useState(match.params.id);

  const [Category, setCategory] = useState({});
  
  const formik = useFormik({
    enableReinitialize : true,
    initialValues: {
      Id: Category.Id,
      name: Category.Name
    },

    onSubmit: async (values) => {

      let result = window.confirm("Are you sure?");

      if (result) {

        let isCreate = categoryId === undefined ? true : false;

        if(isCreate){
          const form = new FormData();
          form.append("Name", values.name);
          await categories.create(form);
          history.goBack();
        }

        else {
          await categories.edit(categoryId, values);
          history.goBack();
        }
      }
    }
  });

  useEffect(() => {

    async function fetchdate(){

    setCategoryId(match.params.id);

    if (categoryId !== undefined) {
      await fetchCategory(categoryId);
      console.log(formik.initialValues);
    }
    
  }

  fetchdate();

  }, [match.params.id]);

  const fetchCategory = async (itemId) => {

    console.log(categories.get(itemId));

    setCategory(await (await categories.get(itemId)).data)

  };
  
  return (
    <Form onSubmit={formik.handleSubmit}>
      <Label htmlFor="exampleAddress">ID</Label>
      <Input type="number" name="Id" id="ID" onChange={formik.handleChange} value={categoryId} disabled/>

      <Label htmlFor="exampleAddress2">Category name</Label>
      <Input type="text" name="name" id="name" onChange={formik.handleChange} value={formik.values.name}/>
      <button type="submit">
        Submit
      </button>
    </Form>
    );
}

export default withRouter(EditCategories);