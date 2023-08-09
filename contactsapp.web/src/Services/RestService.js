import axios from 'axios';

const apiBaseUrl = 'https://localhost:7039/';

const RestService = {
  getContactByEncodedName: async (encodedName) => {
    try {
      const response = await axios.get(`${apiBaseUrl}api/Contact/${encodedName}/Details`);
      return response.data;
    } catch (error) {
      console.error(error);
      throw error;
    }
  },

  getAllContacts: async () => {
    try {
      const response = await axios.get(`${apiBaseUrl}api/Contact/GetAll`);
      return response.data;
    } catch (error) {
      console.error(error);
      throw error;
    }
  },

  createContact: async (contactData) => {
    try {
      const response = await axios.post(`${apiBaseUrl}api/Contact/Create`, contactData);
      return response.data;
    } catch (error) {
      console.error(error);
      throw error;
    }
  },

  editContact: async (encodedName) => {
    try {
        const response = await axios.put(`${apiBaseUrl}api/Contact/${encodedName}/Edit`);
        return response.data;
    } catch (error) {
      console.error(error);
      throw error;
    }
  }
};

export default RestService;
