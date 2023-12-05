import Cookies from 'js-cookie';

export const checkAuthentication = () => {
  const jwtToken = Cookies.get('jwtToken');
  return !!jwtToken;
};