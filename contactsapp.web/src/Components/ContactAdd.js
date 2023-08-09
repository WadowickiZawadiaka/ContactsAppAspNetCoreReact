import React from 'react';
import { useFormik } from 'formik';
import * as yup from 'yup';
import RestService from '../Services/RestService';

const ContactAdd = () => {
    const validationSchema = yup.object().shape({
        firstName: yup.string().required('First Name is required').min(3, 'First Name must be at least 3 characters'),
        lastName: yup.string().required('Last Name is required').min(3, 'Last Name must be at least 3 characters'),
        email: yup.string().required('Email is required').email('Invalid email format'),
        password: yup.string().required('Password is required').min(5, 'Password must be at least 5 characters'),
        confirmPassword: yup.string().required('Confirm Password is required').oneOf([yup.ref('password'), null], 'Passwords must match'),
        phone: yup.string().min(8, 'Phone must be between 8 and 12 characters').max(12, 'Phone must be between 8 and 12 characters').notRequired(),
        dateOfBirth: yup.date().nullable(),
      });

    const formik = useFormik({
        initialValues: {
          firstName: '',
          lastName: '',
          email: '',
          password: '',
          confirmPassword: '',
          category: '',
          subcategory: '',
          phone: '',
          dateOfBirth: '',
          encodedName: '',
        },
        
    validationSchema: validationSchema,
    onSubmit: async (values) => {
      try {
        const formattedDateOfBirth = new Date(values.dateOfBirth).toISOString();
        const updatedValues = { ...values, dateOfBirth: formattedDateOfBirth, encodedName: '' };

        const response = await RestService.createContact(updatedValues);

        console.log('Contact created:', response.data);
        window.alert("Utworzono nowy kontakt.");
    } catch (error) {
        console.error('Error creating contact:', error);
        window.alert("Błąd podczas tworzenia nowego kontaktu.");
    }
    },
  });

  return (
    <div className="container mt-4">
      <h2>Add New Contact</h2>
      <form onSubmit={formik.handleSubmit}>
        <div className="mb-3">
          <label htmlFor="firstName" className="form-label">First Name</label>
          <input
            type="text"
            className={`form-control ${formik.touched.firstName && formik.errors.firstName ? 'is-invalid' : ''}`}
            id="firstName"
            name="firstName"
            value={formik.values.firstName}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.firstName && formik.errors.firstName ? <div className="invalid-feedback">{formik.errors.firstName}</div> : null}
        </div>
        <div className="mb-3">
          <label htmlFor="lastName" className="form-label">Last Name</label>
          <input
            type="text"
            className={`form-control ${formik.touched.lastName && formik.errors.lastName ? 'is-invalid' : ''}`}
            id="lastName"
            name="lastName"
            value={formik.values.lastName}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.lastName && formik.errors.lastName ? <div className="invalid-feedback">{formik.errors.lastName}</div> : null}
        </div>
        <div className="mb-3">
          <label htmlFor="email" className="form-label">Email</label>
          <input
            type="email"
            className={`form-control ${formik.touched.email && formik.errors.email ? 'is-invalid' : ''}`}
            id="email"
            name="email"
            value={formik.values.email}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.email && formik.errors.email ? <div className="invalid-feedback">{formik.errors.email}</div> : null}
        </div>
        <div className="mb-3">
          <label htmlFor="password" className="form-label">Password</label>
          <input
            type="password"
            className={`form-control ${formik.touched.password && formik.errors.password ? 'is-invalid' : ''}`}
            id="password"
            name="password"
            value={formik.values.password}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.password && formik.errors.password ? <div className="invalid-feedback">{formik.errors.password}</div> : null}
        </div>
        <div className="mb-3">
          <label htmlFor="confirmPassword" className="form-label">Confirm Password</label>
          <input
            type="password"
            className={`form-control ${formik.touched.confirmPassword && formik.errors.confirmPassword ? 'is-invalid' : ''}`}
            id="confirmPassword"
            name="confirmPassword"
            value={formik.values.confirmPassword}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.confirmPassword && formik.errors.confirmPassword ? <div className="invalid-feedback">{formik.errors.confirmPassword}</div> : null}
        </div>
        <div className="mb-3">
          <label htmlFor="category" className="form-label">Category</label>
          <input
            type="text"
            className={`form-control ${formik.touched.category && formik.errors.category ? 'is-invalid' : ''}`}
            id="category"
            name="category"
            value={formik.values.category}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.category && formik.errors.category ? <div className="invalid-feedback">{formik.errors.category}</div> : null}
        </div>
        <div className="mb-3">
          <label htmlFor="subcategory" className="form-label">Subcategory</label>
          <input
            type="text"
            className={`form-control ${formik.touched.subcategory && formik.errors.subcategory ? 'is-invalid' : ''}`}
            id="subcategory"
            name="subcategory"
            value={formik.values.subcategory}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.subcategory && formik.errors.subcategory ? <div className="invalid-feedback">{formik.errors.subcategory}</div> : null}
        </div>
        <div className="mb-3">
          <label htmlFor="phone" className="form-label">Phone</label>
          <input
            type="text"
            className={`form-control ${formik.touched.phone && formik.errors.phone ? 'is-invalid' : ''}`}
            id="phone"
            name="phone"
            value={formik.values.phone}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.phone && formik.errors.phone ? <div className="invalid-feedback">{formik.errors.phone}</div> : null}
        </div>
        <div className="mb-3">
          <label htmlFor="dateOfBirth" className="form-label">Date of Birth</label>
          <input
            type="date"
            className={`form-control ${formik.touched.dateOfBirth && formik.errors.dateOfBirth ? 'is-invalid' : ''}`}
            id="dateOfBirth"
            name="dateOfBirth"
            value={formik.values.dateOfBirth}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.dateOfBirth && formik.errors.dateOfBirth ? <div className="invalid-feedback">{formik.errors.dateOfBirth}</div> : null}
        </div>
        <button type="submit" className="btn btn-primary">
          Create Contact
        </button>
      </form>
    </div>
  );
}

export default ContactAdd;
