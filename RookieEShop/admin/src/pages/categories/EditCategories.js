import React from 'react';
import { Col, Row, Button, Form, FormGroup, Label, Input } from 'reactstrap';

const EditCategories = (props) => {
  return (
    <Form>
        <FormGroup>
            <Label for="exampleAddress">ID</Label>
            <Input type="text" name="ID" id="EditCategory1"/>
        </FormGroup>
        <FormGroup>
            <Label for="exampleAddress2">Category name</Label>
            <Input type="text" name="categoryname" id="EditCategory2"/>
        </FormGroup>
        <div className="pt-3">
            <Button color="primary" className="mr-3" onClick={handleSubmit}>
              Save
            </Button>
            <Button color="danger" onClick={() => onCancel && onCancel()}>
              Cancel
            </Button>
        </div>
    </Form>
    );
}

export default EditCategories;