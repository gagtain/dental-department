from rest_framework import serializers

from .models import Dentist, Department, Services, MyUser, Basket, Zakaz


class DentistRetrieveSerializers(serializers.ModelSerializer):
    class Meta:
        model = Dentist
        depth = 1
        fields = '__all__'


class DentistUpdateSerializers(serializers.ModelSerializer):
    class Meta:
        model = Dentist
        fields = '__all__'


class DepartmentUpdateSerializers(serializers.ModelSerializer):
    class Meta:
        model = Department
        fields = '__all__'


class ProductZakazSerializers(serializers.ModelSerializer):

    class Meta:
        model = Services
        fields = ['id', 'name', 'price']


class BasketsZakazSerializers(serializers.ModelSerializer):
    product = ProductZakazSerializers('product')
    class Meta:
        model = Basket
        fields = ['id', 'count', 'summa', 'product']



class ZakazSerializers(serializers.ModelSerializer):
    baskets = BasketsZakazSerializers('baskets', many=True)
    class Meta:
        model = Zakaz
        fields = ['id','baskets', 'data', 'summa']


class DepartmentRetrieveSerializers(serializers.ModelSerializer):
    class Meta:
        model = Department
        depth = 1
        fields = '__all__'


class ServicesUpdateSerializers(serializers.ModelSerializer):
    class Meta:
        model = Services
        fields = '__all__'

class ServicesRetrieveSerializers(serializers.ModelSerializer):
    class Meta:
        model = Services
        depth = 1
        fields = ['id','name', 'price']


class MyUserRetrieveSerializers(serializers.ModelSerializer):
    class Meta:
        model = MyUser
        fields = ['id', 'FIO', 'email', 'State','Age','role']




class UserBasketSerializer(serializers.ModelSerializer):
    baskets = BasketsZakazSerializers('baskets', many=True)
    class Meta:
        model = MyUser
        fields = ['baskets']



class MyUserCreateSerializers(serializers.ModelSerializer):
    class Meta:
        model = MyUser
        fields = '__all__'


class MyUserBasketSerializers(serializers.ModelSerializer):
    class Meta:
        model = MyUser
        fields = ['baskets']

class MyUserBasketeSerializers(serializers.ModelSerializer):
    class Meta:
        model = Basket
        depth = 1
        fields = ['count']
