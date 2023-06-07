import { makeAutoObservable, runInAction } from "mobx";
import { makePersistable } from "mobx-persist-store";
import agent from "../api/account_agent.jsx";
import { store } from "./store.js";

export default class UserStore {
  isApplicant = false;
  user = null;
  error = false;
  student = null;

  constructor() {
    makeAutoObservable(this);

    makePersistable(this, {
      name: "UserStore",
      properties: ["user"],
      storage: window.localStorage,
    });
  }

  get isLoggedIn() {
    return this.user ? true : false;
  }

  login = async (creds) => {
    try {
      const user = await agent.Account.login(creds);
      store.commonStore.setToken(user.token);
      runInAction(() => (this.user = user));
      this.removeError();
    } catch (error) {
      console.log("Invalid credentials");
      this.triggerError();
      throw error;
    }
  };

  register = async (creds) => {
    try {
      const user = await agent.Account.register(creds);
      store.commonStore.setToken(user.token);
      runInAction(() => (this.user = user));
      return true;
    } catch (error) {
      return false;
    }
  };

  logout = () => {
    store.commonStore.setToken(null);
    window.localStorage.removeItem("jwt");
    this.user = null;
    window.location.replace("/login");
  };

  getUser = async () => {
    try {
      const user = await agent.Account.current();
      runInAction(() => (this.user = user));
    } catch (error) {
      console.log(error);
    }
  };

  getStudent = async () => {
    try {
      const student = await agent.Account.student();
      runInAction(() => (this.student = student));
    } catch (error) {
      console.log(error);
    }
  };

  getCurrentUserId = async () => {
    try {
      const userId = await agent.Account.currentId();
      return userId;
    } catch (error) {
      console.log(error);
      return "";
    }
  };

  getRoles = async () => {
    try {
      const roles = agent.Account.roles();
      return roles;
    } catch (error) {
      console.log(error);
      return [];
    }
  };

  updateStudent = async (student) => {
    try {
      await agent.Account.update(student);
      runInAction(() => (this.student = student));
      return true;
    } catch (error) {
      console.log(error);
      return false;
    }
  }

  async fetchIsApplicant() {
    try {
      const roles = await agent.Account.roles();
      this.isApplicant = roles.includes("Applicant");
    } catch (error) {
      console.log(error);
    }
  }

  /*   getRoles = async (): Promise<string[]> => {
    try {
      const roles = await agent.Account.roles;
      return roles;
    } catch (error) {
      console.log(error);
      return [];
    }
  }; */

  triggerError = () => {
    this.error = true;
  };
  removeError = () => {
    this.error = false;
  };
}
