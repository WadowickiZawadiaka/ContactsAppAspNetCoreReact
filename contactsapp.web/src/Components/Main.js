import React, { useState } from 'react';
import { BrowserRouter as Router, Link, Route, Routes } from 'react-router-dom';
import ContactList from './ContactList';
import ContactDetails from './ContactDetails';
import ContactAdd from './ContactAdd';
import ContactEdit from './ContactEdit';

function Main() {
  const [searchText, setSearchText] = useState('');

  const handleSearchSubmit = (e) => {
    e.preventDefault();
  };

  return (
    <Router>
      <>
        <nav className="navbar navbar-expand-sm navbar-light bg-light">
          <div className="container">
            <Link className="navbar-brand" to="/">
              Kontakty
            </Link>
            <button
              className="navbar-toggler d-lg-none"
              type="button"
              data-bs-toggle="collapse"
              data-bs-target="#collapsibleNavId"
              aria-controls="collapsibleNavId"
              aria-expanded="false"
              aria-label="Toggle navigation"
            >
              <span className="navbar-toggler-icon"></span>
            </button>
            
            <div className="collapse navbar-collapse" id="collapsibleNavId">
              <form className="d-flex my-2 my-lg-0" onSubmit={handleSearchSubmit}>
                <input
                  className="form-control me-sm-2"
                  type="text"
                  placeholder="Filtruj"
                  value={searchText}
                  onChange={(e) => setSearchText(e.target.value)}
                />
                <button className="btn btn-outline-success" type="submit">
                  Szukaj
                </button>
              </form>
            </div>
            <div className="collapse navbar-collapse justify-content-end" id="collapsibleNavId">
              <Link to="/add" className="btn btn-primary me-2">
                Dodaj nowy kontakt
              </Link>
            </div>
          </div>
        </nav>

        <Routes>
          <Route path="/" element={<ContactList searchText={searchText}/>} />
          <Route path="/contact/:encodedName" element={<ContactDetails />} />
          <Route path="/edit/:encodedName" element={<ContactEdit />} />
          <Route path="/add" element={<ContactAdd />} />
        </Routes>
      </>
    </Router>
  );
}

export default Main;
