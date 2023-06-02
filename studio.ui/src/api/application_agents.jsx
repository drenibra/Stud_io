import axios from "axios";

const service2Axios = axios.create({
  baseURL: import.meta.env.VITE_API_APPLICATION_URL,
});

const responseBody = (response) => response.data;

const requests = {
  get: (url) => service2Axios.get(url).then(responseBody),
  post: (url, body) => service2Axios.post(url, body).then(responseBody),
  put: (url, body) => service2Axios.put(url, body).then(responseBody),
  del: (url) => service2Axios.delete(url).then(responseBody),
};

const Apply = {
  apply: (values) => requests.post("AddApplication", values),
};

const agent = {
  Apply,
};

export default agent;
