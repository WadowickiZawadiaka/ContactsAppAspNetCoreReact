import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import RestService from '../Services/RestService';

function ContactDetails() {
  const { encodedName } = useParams();
  const [contact, setContact] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchContact = async () => {
      try {
        const contactData = await RestService.getContactByEncodedName(encodedName);
        setContact(contactData);
        setLoading(false);
      } catch (error) {
        setError(error);
        setLoading(false);
      }
    };

    fetchContact();
  }, [encodedName]);

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>Error loading contact details.</div>;
  }

  if (!contact) {
    return <div>Contact not found.</div>;
  }

  return (
    <div className="container mt-4">
      <h2 className="mb-3">Contact Details</h2>
      <div className="card">
        <div className="card-body">
          <h5 className="card-title">{contact.firstName} {contact.lastName}</h5>
          <p className="card-text"><strong>Email:</strong> {contact.email}</p>
          <p className="card-text"><strong>Phone:</strong> {contact.phone}</p>
          <p className="card-text"><strong>Category:</strong> {contact.category}</p>
          <p className="card-text"><strong>Subcategory:</strong> {contact.subcategory}</p>
          <p className="card-text"><strong>Date of Birth:</strong> {new Date(contact.dateOfBirth).toLocaleDateString()}</p>
        </div>
      </div>
    </div>
  );
}

export default ContactDetails;
