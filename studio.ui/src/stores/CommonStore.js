import { makeAutoObservable, reaction } from "mobx";

export default class CommonStore {
  token = window.localStorage.getItem("jwt");
  appLoaded = false;

  constructor() {
    makeAutoObservable(this);

    reaction(
      () => this.token,
      (token) => {
        if (token) {
          window.localStorage.setItem("jwt", token);
        } else {
          window.localStorage.removeItem("jwt");
        }
      }
    );
  }

  setToken = (token) => {
    this.token = token;
  };
  setAppLoaded = () => {
    this.appLoaded = true;
  };
}
