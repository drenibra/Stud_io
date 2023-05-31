import axios from 'axios';
import { store } from '../stores/store';

const sleep = (delay) => {
  return new Promise((resolve) => {
    setTimeout(resolve, delay);
  });
};

axios.defaults.baseURL = 'https://localhost:7120/api/v1';

axios.interceptors.request.use(
  (config) => {
    const token = store.commonStore.token;
    if (token) config.headers.Authorization = `Bearer ${token}`;
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

axios.interceptors.response.use(async (response) => {
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
  get: (url) => axios.get(url).then(responseBody),
  post: (url, body) => axios.post(url, body).then(responseBody),
  put: (url, body) => axios.put(url, body).then(responseBody),
  del: (url) => axios.delete(url).then(responseBody),
};

const Account = {
  current: () => requests.get('/account'),
  student: () => requests.get('/account/student'),
  login: (user) => requests.post('/Account/login', user),
  register: (user) => requests.post('/Account/register', user),
  currentId: () => requests.get('/account/currentId'),
  roles: () => requests.get('/account/roles'),
};

const agent = {
  Account,
};

export default agent;
