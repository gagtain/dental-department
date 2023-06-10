from .custom_mixin import custom_retrieve
from rest_framework import viewsets, mixins

class BaseAPI(
                 custom_retrieve,
                 mixins.CreateModelMixin,
                 mixins.UpdateModelMixin,
                 mixins.DestroyModelMixin,
                 mixins.ListModelMixin,
                 viewsets.GenericViewSet):
    pass





