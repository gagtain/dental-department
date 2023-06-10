from rest_framework import status
from django.shortcuts import get_object_or_404
from rest_framework.response import Response

from ..custom_mixin import custom_get_serializer
from ..models import Zakaz, Basket, MyUser, Services
from ..serializers import ZakazSerializers, MyUserBasketSerializers, UserBasketSerializer, \
    BasketsZakazSerializers, MyUserRetrieveSerializers
from ..BaseAPI import BaseAPI


class BasketAPI(custom_get_serializer,BaseAPI):
    queryset = Basket.objects.all()
    serializer_class = MyUserRetrieveSerializers
    serializer_class_update_or_create = BasketsZakazSerializers


    def retrieve_product(self, request, pk):
        basket_in_user = MyUser.objects.get(pk=pk)
        return Response(UserBasketSerializer(instance=basket_in_user).data, status=status.HTTP_200_OK)

    def add_product(self, request, pk):
        user = get_object_or_404(MyUser, pk=pk)
        ser = get_object_or_404(Services, pk=request.query_params['pr'])
        obj_ser = Basket.objects.create(User=user, product=ser, count=request.query_params['count'])
        user.baskets.add(obj_ser)

        return Response(MyUserBasketSerializers(user).data, status=status.HTTP_200_OK)

    def remove_product(self, request, pk):
        user = get_object_or_404(MyUser, pk=pk)
        Bas = get_object_or_404(Basket, pk=request.query_params['pr'])
        Bas.delete()

        return Response(MyUserBasketSerializers(user).data, status=status.HTTP_200_OK)

    def add_upload_baskets(self, request, pk):
        user = get_object_or_404(MyUser, pk=pk)
        try:
            up_list = request.data["uploader_id"]
            if type(up_list) != list:
                up_list = up_list.split(",")
        except KeyError:
            return Response({'error': 'не введен массив uploader_id'},status=status.HTTP_400_BAD_REQUEST)
        up_obj_list = []
        for id in up_list:
            basket_ = get_object_or_404(Basket, pk=id)
            if basket_ in user.baskets.all():
                up_obj_list.append(basket_)
            else:
                return Response({'error': f'объекта корзины с id равным {basket_.id} нету'},status=status.HTTP_400_BAD_REQUEST)
        zakaz = Zakaz.objects.create()
        for obj in up_obj_list:
            zakaz.baskets.add(obj)
            user.baskets.remove(obj)
        user.zakaz_list.add(zakaz)
        zakaz.save()
        return Response(ZakazSerializers(instance=zakaz).data)