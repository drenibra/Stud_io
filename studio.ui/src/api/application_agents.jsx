import axios from "axios";

axios.defaults.baseURL = "https://localhost:7007/";

const responseBody = (response) => response.data;

const requests = {
  get: (url) => axios.get(url).then(responseBody),
  post: (url, body) => axios.post(url, body).then(responseBody),
  put: (url, body) => axios.put(url, body).then(responseBody),
  del: (url) => axios.delete(url).then(responseBody),
};

const Apply = {
  apply: (values) => requests.post("AddApplication", values),
};

const agent = {
  Apply,
};

export default agent;
