<template>
    <div id="home-frame">
        <DForm action="/" method="POST">
            <TextInput name="username" isRequired="true" placeHolder="Username"/>
            <EmailInput name="email" isRequired="true" placeHolder="Email"/>
            <TextInput name="firstname" isRequired="true" placeHolder="First Name"/>
            <TextInput name="lastname" isRequired="true" placeHolder="Last Name"/>
            <PasswordInput name="password" isRequired="true" placeHolder="Password"/>
        </DForm>
    </div>
</template>

<style>
    #home-frame {
        width: 40%;
        height: 55%;
        /* left: 403px;
        top: 455px;   */
        margin: 40px;
        background: rgba(255, 255, 255, 0.3);
        border-radius: 50px;
        backdrop-filter: blur(30px);
        box-shadow: 10px 5px 10px #00000010;
    }
</style>

<script>
import TextInput from '@/components/Login/TextInput.vue'
import DForm from '@/components/Login/DForm.vue'
import EmailInput from '@/components/Login/EmailInput'
import PasswordInput from '@/components/Login/PasswordInput.vue'

export default {
  name: 'HomeFrame',
  components: {
    TextInput, EmailInput, PasswordInput, DForm
  }
}
</script>