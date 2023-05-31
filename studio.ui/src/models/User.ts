import Major from './Major';

export interface User {
  firstName: string;
  lastName: string;
  username: string;
  token: string;
}

export interface UserRegister {
  firstName: string;
  lastName: string;
  gender: string;
  email: string;
  password: string;
  username: string;
}

export interface UserFormValues {
  email: string;
  password: string;
  username?: string;
}

export interface AppUser {
  name: string;
  surname: string;
}

export interface Student {
  name: string;
  surname: string;
  email: string;
  fathersName: string | null;
  city: string | null;
  gpa: string | null;
  status: string | null;
  major: Major | null;
  dormNumber: string | null;
}