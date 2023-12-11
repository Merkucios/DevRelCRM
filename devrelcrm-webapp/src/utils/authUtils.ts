import Cookies from 'js-cookie';
import jwt, { JwtPayload } from 'jsonwebtoken';

export const checkAuthentication = () => {
  const jwtToken = Cookies.get('jwtToken');
  return !!jwtToken;
};

export const getJwtToken = () => {
  const jwtToken = Cookies.get('jwtToken');
  return jwtToken
};

export const logout = () => {
  Cookies.remove('jwtToken');
  window.location.reload();
};

export const getRoleFromToken = (token: string | undefined): string => {
  const rolePath = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role';

  try {
    const decoded = jwt.decode(token!) as JwtPayload;
    console.log(decoded);

    if (decoded && decoded[rolePath]) {
      return decoded[rolePath] as string;
    } else {
      return 'defaultRole';
    }
  } catch (error) {
    console.error('Ошибка при декодировании токена:', error);
    return 'defaultRole';
  }
};