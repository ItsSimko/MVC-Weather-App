// Composables
import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    component: () => import('@/layouts/default/Default.vue'),
    children: [
      {
        path: '/',
        name: 'Home',
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () => import(/* webpackChunkName: "home" */ '@/views/WeatherContainer.vue'),
      },
      {
        path: '/forecast',
        name: 'Forecast',
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () => import(/* webpackChunkName: "home" */ '@/views/WeatherContainer.vue'),
      },
      {
        path: '/login',
        name: 'Login',
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited
        component: () => import(/* webpackChunkName: "home" */ '@/views/Login.vue'),
      },
      {
        path: '/register',
        name: 'Registration',
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () => import(/* webpackChunkName: "home" */ '@/views/RegistrationPage.vue'),
      },
      {
      path: '/panel',
      name: 'User & admin panel',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      meta: { requiresAuth: true },
      component: () => import(/* webpackChunkName: "home" */ '@/views/UserPanel.vue'),
      },

    ],
  },
]

const router = createRouter({ 
  history: createWebHistory(process.env.BASE_URL),
  routes,
})

router.beforeEach((to, from, next) => {
  console.log("before")
  if (to.matched.some(record => record.meta.requiresAuth)) {
    console.log("has required")
    // Check if the user is authenticated
    var user = null; // Implement your authentication logic here

    user = localStorage.getItem("token");
    console.log(user)

    if (!user) {
      console.log("has required2")
      // If the user is not authenticated, redirect to the login page
      next({ path: '/login', query: { redirect: to.fullPath } });
    } else {
      // If the user is authenticated, proceed to the route
      next();
    }
  } else {
    // If the route doesn't require authentication, proceed as usual
    next();
  }
});

export default router
