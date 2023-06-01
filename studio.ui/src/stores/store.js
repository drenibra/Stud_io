import { createContext, useContext } from "react";
import CommonStore from "./CommonStore";
import UserStore from "./userStore";

export const store = {
  commonStore: new CommonStore(),
  userStore: new UserStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
