import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import RestService from '../Services/RestService';

function ContactList({ searchText }) {
  const [contacts, setContacts] = useState([]);

  const filteredContacts = searchText
    ? contacts.filter(contact =>
        contact.firstName.toLowerCase().includes(searchText.toLowerCase()) ||
        contact.lastName.toLowerCase().includes(searchText.toLowerCase()) ||
        contact.email.toLowerCase().includes(searchText.toLowerCase()) ||
        contact.category.toLowerCase().includes(searchText.toLowerCase()) ||
        contact.subcategory.toLowerCase().includes(searchText.toLowerCase())
      )
    : contacts;

  useEffect(() => {
    const fetchContacts = async () => {
      try {
        const contactsData = await RestService.getAllContacts();
        setContacts(contactsData);
      } catch (error) {
        console.error(error);
      }
    };

    fetchContacts();
  }, []);

  const handleDelete = async (encodedName) => {
    try {
      await RestService.deleteContact(encodedName);
      setContacts(prevContacts => prevContacts.filter(contact => contact.encodedName !== encodedName));
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div className="container mt-4">
      <div className="text-center">
        <h2 className="mb-3">Lista kontaktów</h2>
      </div>
      <ul className="list-group">
        {filteredContacts.map((contact, index) => (
          <li key={index} className="list-group-item d-flex justify-content-between align-items-center">
            <div>
              <Link to={`/contact/${contact.encodedName}`}>
                {contact.firstName} {contact.lastName}
              </Link>
              <p className="mb-0">Email: {contact.email}</p>
              <p className="mb-0">Category: {contact.category}</p>
              <p className="mb-0">Subcategory: {contact.subcategory}</p>
            </div>
            <div>
              <Link to={`/edit/${contact.encodedName}`} className="btn btn-outline-primary me-2">
                Edit
              </Link>
              <Link to={`/contact/${contact.encodedName}`} className="btn btn-outline-primary me-2">
                Details
              </Link>
              <button
                className="btn btn-outline-danger"
                onClick={() => handleDelete(contact.encodedName)}
              >
                Delete
              </button>
            </div>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default ContactList;
