import { makeAutoObservable, runInAction } from 'mobx';
import { makePersistable } from 'mobx-persist-store';
import agent from '../api/account_agent.jsx';
import paymentAgent from '../api/payment_agents.jsx';
import { store } from './store.js';

export default class UserStore {
  user = null;
  error = false;
  student = null;
  roles = null;

  constructor() {
    makeAutoObservable(this);

    makePersistable(this, {
      name: 'UserStore',
      properties: ['user', 'student', 'roles'],
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
      this.updateUserImage(user.profileImage);
      this.removeError();
      this.getRoles();
      if (user.token) return true;
      else return false;
    } catch (error) {
      console.log('Invalid credentials');
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
    window.localStorage.removeItem('jwt');

    this.user = null;
    this.student = null;
    this.roles = null;

    window.location.replace('/login');
  };

  getProfileImage() {
    return this.user.image;
  }

  updateUserImage(response) {
    this.user.image = response;
  }

  deleteUserImage() {
    this.user.image = null;
  }

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
      return student;
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
      return '';
    }
  };

  updateUser = async (user) => {
    try {
      await agent.Account.update(user);
      if (this.getRoles[0] === 'Student') {
        runInAction(() => (this.student = student));
      } else if (this.getRoles[0] === 'Admin') {
        runInAction(() => (this.user = user));
      }
      return true;
    } catch (error) {
      console.log(error);
      return false;
    }
  };

  getPayments = async (customerId) => {
    try {
      const payments = await paymentAgent.Payments.getPaymentsOfCustomer(customerId);
      return payments;
    } catch (error) {
      console.log(error);
    }
  };

  getRoles = async () => {
    try {
      const roles = await agent.Account.roles();
      runInAction(() => (this.roles = roles));
      return roles;
    } catch (error) {
      console.log(error);
      return [];
    }
  };

  triggerError = () => {
    this.error = true;
  };
  removeError = () => {
    this.error = false;
  };

  uploadPhoto = async (file) => {
    this.uploading = true;
    try {
      const response = await agent.Profiles.uploadPhoto(file);
      const photo = response.data;
      runInAction(() => {
        if (this.profile) {
          this.profile.photos?.push(photo);
          if (photo.isMain && store.userStore.user) {
            store.userStore.setImage(photo.url);
            this.profile.image = photo.url;
          }
        }
        this.uploading = false;
      });
    } catch (error) {
      console.log(error);
      runInAction(() => (this.uploading = false));
    }
  };

  setMainPhoto = async (photo) => {
    this.loading = true;
    try {
      await agent.Profiles.setMainPhoto(photo.id);
      store.userStore.setImage(photo.url);
      runInAction(() => {
        if (this.profile && this.profile.photos) {
          this.profile.photos.find((a) => a.isMain).isMain = false;
          this.profile.photos.find((a) => a.id === photo.id).isMain = true;
          this.profile.image = photo.url;
          this.loading = false;
        }
      });
    } catch (error) {
      console.log(error);
      runInAction(() => (this.loading = false));
    }
  };

  deletePhoto = async (photo) => {
    this.loading = true;
    try {
      await agent.Profiles.deletePhoto(photo.id);
      runInAction(() => {
        if (this.profile) {
          this.profile.photos = this.profile.photos?.filter((a) => a.id !== photo.id);
          this.loading = false;
        }
      });
    } catch (error) {
      // toast.error('Problem deleting photo');
      this.loading = false;
    }
  };
}
