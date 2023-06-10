from django.contrib.auth.models import AbstractBaseUser
from django.core.validators import MinLengthValidator, integer_validator, RegexValidator
from django.db import models


# Create your models here.


class MyUser(AbstractBaseUser):
    class ROLE_CHOICES(models.TextChoices):
        ADMIN = "ADMIN", "ADMIN"
        USER = "USER", "USER"

    FIO = models.CharField(max_length=100)
    email = models.EmailField()
    State = models.CharField(max_length=150)
    Age = models.PositiveIntegerField()
    baskets = models.ManyToManyField('Basket', blank=True)
    zakaz_list = models.ManyToManyField('Zakaz', blank=True)
    role = models.CharField(max_length=21, choices=ROLE_CHOICES.choices, default='USER')

    def __str__(self):
        return self.FIO


class Zakaz(models.Model):
    baskets = models.ManyToManyField('Basket')
    data = models.DateTimeField(auto_now_add=True)
    summa = models.FloatField()
    def __str__(self):
        return f"Заказ № {self.id}"

    def save(self, *args, **kwargs):
        try:
            print(self.baskets.all())
            for i in self.baskets.all():
                self.summa += i.summa
        except ValueError:
            self.summa = 0
        return super(Zakaz, self).save(*args, **kwargs)




class Basket(models.Model):
    User = models.ForeignKey('MyUser', on_delete=models.CASCADE)
    product = models.ForeignKey('Services', on_delete=models.CASCADE, related_name='product')
    count = models.PositiveIntegerField()
    summa = models.PositiveIntegerField()
    data = models.DateTimeField(auto_now_add=True)
    def __str__(self):
        return self.product.name

    def save(self, *args, **kwargs):
        self.summa = int(self.count) * int(self.product.price)
        return super(Basket, self).save(*args, **kwargs)

    def create(self, *args, **kwargs):
        return super(Basket, self).save(*args, **kwargs)

class Dentist(models.Model):
    name = models.CharField(max_length=50)
    sertificate_id = models.CharField(max_length=50, validators=[integer_validator])
    seria_nomer = models.CharField(max_length=40, validators=[integer_validator])


    def __str__(self):
        return self.name


class Department(models.Model):
    name = models.CharField(max_length=50, validators=[MinLengthValidator(1)])
    time_job = models.CharField(max_length=50, validators=[RegexValidator(regex="\d\d:\d\d-\d\d:\d\d",
                                                                          message="Неправильное значение, пример: 11:00-17:00")])
    dentist = models.ForeignKey('Dentist', on_delete=models.CASCADE, null=True)
    services = models.ManyToManyField('Services', blank=False, related_name='services_list')

    def __str__(self):
        return self.name



class Services(models.Model):
    name = models.CharField(max_length=100)
    price = models.PositiveIntegerField()

    def __str__(self):
        return self.name

