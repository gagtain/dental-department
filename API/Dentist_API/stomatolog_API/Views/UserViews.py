import base64

from django.shortcuts import get_object_or_404
from rest_framework.exceptions import ParseError
from rest_framework.response import Response

from ..custom_mixin import custom_get_serializer
from ..serializers import *
from rest_framework import status

from ..BaseAPI import BaseAPI


class MyUserAPI(custom_get_serializer,BaseAPI):

    queryset = MyUser.objects.all()
    serializer_class = MyUserRetrieveSerializers
    serializer_class_update_or_create = MyUserCreateSerializers

    def create(self, request, *args, **kwargs):
        serializer = self.get_serializer(data=request.data)
        if serializer.is_valid(raise_exception=True):
            print('df')
            self.perform_create(serializer)
            FIO = serializer.data.get('email')
            password = serializer.data.get('password')
            token = f"{FIO}:{password}"
            b = base64.b64encode(bytes(token, 'utf-8'))
            return Response(data=b, status=status.HTTP_201_CREATED)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)

    def init_reg(self, request):
        try:
            token = request.GET['token']
        except:
            raise ParseError('токен не был передан')
        token = base64.b64decode(bytes(token, 'utf-8'))
        token = token.decode("utf-8").split(':')
        user = get_object_or_404(MyUser, **{'email':token[0], 'password': token[1]})
        return Response(self.serializer_class(user).data)


    def auth(self, request):
        try:
            email = request.GET['email']
            password = request.GET['password']
        except:
            raise ParseError('токен не был передан')
        get_object_or_404(MyUser, **{'email': email, 'password': password})
        b = base64.b64encode(bytes(f"{request.GET['email']}:{request.GET['password']}", 'utf-8'))
        return Response(data=b, status=status.HTTP_200_OK)