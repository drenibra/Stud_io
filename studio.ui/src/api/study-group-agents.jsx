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
  getAll: (filter) => requests.get("StudyGroup" + filter),
  getById: (id) => requests.get("StudyGroup/" + id),
};

const Posts = {
  getAll: (filter) => requests.get("Post" + filter),
  getById: (id) => requests.get("Post/" + id),
};

const Resources = {
  getAll: (filter) => requests.get("Resource" + filter),
  getById: (id) => requests.get("Resource/" + id),
};

const GroupEvents = {
  getAll: (filter) => requests.get("GroupEvent" + filter),
  getById: (id) => requests.get("GroupEvent/" + id),
};

const agent = {
  StudyGroups,
  Posts,
  Resources,
  GroupEvents,
};

export default agent;
