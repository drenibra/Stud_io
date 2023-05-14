import axios from "axios";

axios.defaults.baseURL = "https://localhost:7163/api/";

const responseBody = (response) => response.data;

const requests = {
  get: (url) => axios.get(url).then(responseBody),
  post: (url, body) => axios.post(url, body).then(responseBody),
  put: (url, body) => axios.put(url, body).then(responseBody),
  del: (url) => axios.delete(url).then(responseBody),
};

const Payments = {
  create: (values) => requests.post(`Payment/AddPayment`, values),
};

const agent = {
  Payments,
};

export default agent;
