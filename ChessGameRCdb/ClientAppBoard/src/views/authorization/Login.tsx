import { refreshTokenSetup } from './utils/refreshToken';
import { useAppDispatch } from 'state/hooks'
import { loggedIn } from 'views/menu/MenuSlice'
import { useGoogleLogin } from 'react-google-login'
import { Button } from "reactstrap";

const clientId = '778159703392-1vbp93089n4t90eadabigdedmdti97id.apps.googleusercontent.com';

function Login() {
    const dispatch = useAppDispatch();

    const onSuccess = (res: any) => {
        var tokenId = res.tokenId;
        var name = res.profileObj.name;
        var familyName = res.profileObj.familyName;
        var givenName = res.profileObj.givenName;
        var email = res.profileObj.email;
        var googleId = res.profileObj.googleId;

        dispatch(loggedIn({
            tokenId: tokenId,
            name: name,
            familyName: familyName,
            givenName: givenName,
            email: email,
            googleId: googleId
        }))

        refreshTokenSetup(res);
    };

    const onFailure = (res: any) => {
        alert(
            `Failed to login.`
        );
    };

    const { signIn } =
        useGoogleLogin({
            clientId: clientId,
            loginHint: "You will be redirected to authenticate",
            onSuccess: onSuccess,
            onFailure: onFailure,
            cookiePolicy: 'single_host_origin',
            isSignedIn:  true
        })


    return (
        <Button onClick={() => signIn()} color="primary">Start game</Button>
    );
}

export default Login;