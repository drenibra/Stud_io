import { createContext, useContext } from 'react';
import CommonStore from './CommonStore';
import UserStore from './userStore';

interface Store {
  commonStore: CommonStore;
  userStore: UserStore;
}

export const store: Store = {
  commonStore: new CommonStore(),
  userStore: new UserStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
