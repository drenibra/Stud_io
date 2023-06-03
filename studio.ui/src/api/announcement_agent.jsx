// import axios from "axios";

// const service3Axios = axios.create({
//     baseURL: "https://localhost:7137/api/" //import.meta.env.VITE_API_ANNOUNCEMENT_URL,
// });

// const responseBody = (response) => response.data;

// const requests = {
//     get: (url) => service3Axios.get(url).then(responseBody),
//     post: (url, body) => service3Axios.post(url, body).then(responseBody),
//     put: (url, body) => service3Axios.put(url, body).then(responseBody),
//     del: (url) => service3Axios.delete(url).then(responseBody),
// };

// const AddAnnouncement = {
//     create: (values) => requests.post("Announcement/add-announcement", values),
// };

// const Announcements = {
//     get: (search) =>
//         requests.get("Announcement/get-all-announcements", { search }),
// };

// const agent = {
//     AddAnnouncement,
//     Announcements,
// };

// export default agent;
