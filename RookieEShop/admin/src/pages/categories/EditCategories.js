import React, { useState, useEffect } from 'react';
import { Form, Button, Label, Input, FormGroup } from 'reactstrap';
import { useFormik } from "formik";
import categories from './categories';
import { withRouter } from "react-router-dom";
import history from '../../helpers/history';

const EditCategories = ({ match }) => {

  const [categoryId, setCategoryId] = useState(match.params.id);

  const [Category, setCategory] = useState({
    name: " "
  });
  const [name, setName] = useState("");

  const formik = useFormik({
    enableReinitialize: true,
    initialValues: {
      //name: Category.name ? Category.name : " "
      name: name ? name : " "
    },

    onSubmit: async (values) => {

      let result = window.confirm("Are you sure?");

      if (result) {

        let isCreate = categoryId === undefined ? true : false;

        if (isCreate) {
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

    async function fetchdate() {

      setCategoryId(match.params.id);

      if (categoryId !== undefined) {
        await fetchCategory(categoryId);
        console.log(formik.initialValues.name);
      }

    }

    fetchdate();

  }, [match.params.id]);

  const fetchCategory = async (itemId) => {

    var data = await categories.get(itemId);

    console.log(name);
    setName(data.name);
    //  setCategory(await (await categories.get(itemId)).data)

  };

  return (
    <Form onSubmit={formik.handleSubmit}>
      <FormGroup row>
        <Label htmlFor="exampleAddress2">Category name</Label>
        <Input type="text" name="name" id="name" onChange={formik.handleChange} value={formik.values.name} />
      </FormGroup>

      <FormGroup check row>
        <Button
          color="primary">
          Submit
        </Button>{' '}
        
        <Button
          onClick={() => history.goBack()}
          color="danger">
          Cancel
        </Button>
      </FormGroup>
    </Form>
  );
}

export default withRouter(EditCategories);