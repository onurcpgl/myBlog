import  axios  from "axios";

export async function loginPost(email,password){
   const result=await axios({
        method: 'post',
        url: 'https://localhost:7229/api/login',
        data: {
            emailAdress: email,
            password: password,
        },
        headers: {"Access-Control-Allow-Origin": "*"}
      });
    return result;
}