import axios from "axios";

const serviceAxios = axios.create({
  baseURL: import.meta.env.VITE_API_STUDYGROUPS_URL,
});

const responseBody = (response) => response.data;

const requests = {
  get: (url) => serviceAxios.get(url).then(responseBody),
  post: (url, body) => serviceAxios.post(url, body).then(responseBody),
  put: (url, body) => serviceAxios.put(url, body).then(responseBody),
  del: (url) => serviceAxios.delete(url).then(responseBody),
};

const StudyGroups = {
  getAll: (values) => requests.get("StudyGroup" + values),
};

const agent = {
  StudyGroups,
};

export default agent;
