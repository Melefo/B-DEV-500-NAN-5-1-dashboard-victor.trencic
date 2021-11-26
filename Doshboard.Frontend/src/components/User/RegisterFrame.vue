<template>
    <Frame>
        <form action="/" method="POST">
            <div>
              <input name="firstname" required placeholder="First Name" type="text" v-model="firstname" />
              <input name="lastname" required placeholder="Last Name" type="text" v-model="lastname" />
            </div>
            <div>
              <input name="username" required placeholder="Username" type="text" v-model="username" />
            </div>
            <div>
              <input name="email" required placeholder="Email" type="email" v-model="email" />
            </div>
            <div>
              <input name="password" required placeholder="Password" type="password" v-model="password"/>
              <input name="confirm" required placeholder="Confirm" type="password" v-model="confirm" />
            </div>
            <input type="submit" value="Register" />
        </form>
    </Frame>
</template>

<script>
import Frame from '@/components/Frame.vue'

export default {
  name: 'HomeFrame',
  components: {
    Frame
  },
  data: function() {
    return {
      firstname: "",
      lastname: "",
      username: "",
      email: "",
      password: "",
      confirm: ""
    }
  }
}
</script>