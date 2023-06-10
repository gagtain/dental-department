from django.urls import path, include

from .Views import BasketViews, DentistViews, DepartmentViews, ServicesViews, UserViews, ZakazViews

urlpatterns = [
    path('dentist', DentistViews.DentistAPI.as_view({'get':'list', 'post':'create'})),
    path('dentist/<int:pk>', DentistViews.DentistAPI.as_view({'get':'retrieve', 'put':'update',
                                                              'delete': 'destroy', 'patch':'partial_update'})),
    path('department', DepartmentViews.DepartmentAPI.as_view({'get':'list', 'post':'create'})),
    path('department/<int:pk>', DepartmentViews.DepartmentAPI.as_view({'get':'retrieve', 'put':'update',
                                                                       'delete': 'destroy', 'patch':'partial_update'})),
    path('department/<int:pk>/not_services', DepartmentViews.DepartmentAPI.as_view({'get':'retrieve_not_services'})),
    path('services', ServicesViews.ServicesAPI.as_view({'get':'list', 'post':'create'})),
    path('services/<int:pk>', ServicesViews.ServicesAPI.as_view({'get':'retrieve', 'put':'update',
                                                                 'delete': 'destroy'})),
    path('users', UserViews.MyUserAPI.as_view({'get':'list'})),
    path('users/<int:pk>', UserViews.MyUserAPI.as_view({'get':'retrieve', 'put':'update',
                                                        'delete': 'destroy', 'patch':'partial_update'})),
    path('users/<int:pk>/product', BasketViews.BasketAPI.as_view({'get':'retrieve_product',
                                                                  'post': 'add_product',
                                                                  'delete': 'remove_product'})),
    path('users/<int:pk>/zakaz', ZakazViews.ZakazAPI.as_view({'get':'zakaz_list'})),
    path('users/<int:pk>/zakaz/<int:zakaz_pk>', ZakazViews.ZakazAPI.as_view({'get':'retrieve'})),
    path('users/<int:pk>/product/upload', BasketViews.BasketAPI.as_view({'post': 'add_upload_baskets'})),
    path('product/<int:pk>', BasketViews.BasketAPI.as_view({'patch': 'partial_update'})),
    path('registration', UserViews.MyUserAPI.as_view({'post': 'create', 'get':'init_reg'})),
    path('authorization', UserViews.MyUserAPI.as_view({'get':'auth'}))
]