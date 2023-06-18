import axios from 'axios';
import { store } from '../stores/store';

const sleep = (delay) => {
  return new Promise((resolve) => {
    setTimeout(resolve, delay);
  });
};

const service1Axios = axios.create({
  baseURL: 'http://localhost:5274/api/v1',
});

service1Axios.interceptors.request.use(
  (config) => {
    const token = store.commonStore.token;
    if (token) config.headers.Authorization = `Bearer ${token}`;
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

service1Axios.interceptors.response.use(async (response) => {
  try {
    await sleep(400);
    return response;
  } catch (error) {
    console.log(error);
    return Promise.reject(error);
  }
});

const responseBody = (response) => response.data;

const requests = {
  get: (url) => service1Axios.get(url).then(responseBody),
  post: (url, body) => service1Axios.post(url, body).then(responseBody),
  put: (url, body) => service1Axios.put(url, body).then(responseBody),
  del: (url) => service1Axios.delete(url).then(responseBody),
};

const Account = {
  current: () => requests.get('/account'),
  student: () => requests.get('/account/student'),
  login: (user) => requests.post('/Account/login', user),
  register: (user) => requests.post('/Account/register', user),
  currentId: () => requests.get('/account/currentId'),
  roles: () => requests.get('/account/roles'),
  update: (user) => requests.put('/user', user),
};

const Profiles = {
  get: (username) => requests.get(`/profiles/${username}`),

  uploadPhoto: (file) => {
    let formData = new FormData();
    formData.append('File', file);
    return service1Axios.post('photos', formData, {
      headers: { 'Content-Type': 'multipart/form-data' },
    });
  },
  setMainPhoto: (id) => service1Axios.post(`/photos/${id}/setMain`, {}),
  deletePhoto: (id) => service1Axios.delete(`/photos/${id}`),
};

const agent = {
  Account,
  Profiles,
};

export default agent;
