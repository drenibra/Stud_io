import axios from 'axios';
import { values } from 'mobx';

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
  getAll: (filter) => requests.get('StudyGroup' + filter),
  getById: (id) => requests.get('StudyGroup/' + id),
  joinGroup: (groupId, values) => requests.put('StudyGroup/add-members/' + groupId, values),
  studyGPT: (query) => requests.get('StudyGroup/studio-gpt/' + query),
};

const Posts = {
  getAll: (filter) => requests.get('Post' + filter),
  getById: (id) => requests.get('Post/' + id),
  create: (post) => requests.post('Post/', post),
  likeOrUnlike: (studentId, postId) => requests.post(`Post/likeOrUnlike?studentId=${studentId}&postId=${postId}`),
  comment: (comment) => requests.post('Post/create-comment/', comment),
  deleteComment: (commentId) => requests.del('Post/delete-comment/' + commentId),
};

const Resources = {
  getAll: (filter) => requests.get('Resource' + filter),
  getById: (id) => requests.get('Resource/' + id),
  create: (resource, config) => requests.post('Resource/create-resource', resource, config),
};
const GroupEvents = {
  getAll: (filter) => requests.get('GroupEvent' + filter),
  getById: (id) => requests.get('GroupEvent/' + id),
  confirmGoing: (groupEventId, studentId) => requests.post('GroupEvent/confirm-going/' + groupEventId + '/' + studentId),
};

const agent = {
  StudyGroups,
  Posts,
  Resources,
  GroupEvents,
};

export default agent;
