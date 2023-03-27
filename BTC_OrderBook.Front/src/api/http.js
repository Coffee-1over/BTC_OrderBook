import axios from 'axios';

axios.defaults.baseURL = `https://localhost:7172/api`;

const http = axios.create({
  baseURL: axios.defaults.baseURL,
});


http.interceptors.response.use(
  function (response) {
  
    return response;
  },
  function (error) {
    const msg = error?.response?.data?.error?.message;
  
    return Promise.reject({
      message: msg || 'Error request',
      code: error?.response?.data?.code || error?.response?.status,
    });
  } 
);

export default http;
