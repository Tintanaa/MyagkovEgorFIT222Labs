class Employee:
    def __init__(self, id, name, boss=None):
        self.id = id
        self.name = name
        self.boss = boss
        self.subordinates = []
def find_employee_by_id(employees, id):
    for emp in employees:
        if emp.id == id:
            return emp
    return None
def find_employee_by_name(employees, name):
    for emp in employees:
        if emp.name == name:
            return emp
    return None
def get_all_subordinates(employee, visited=None):
    if visited is None:
        visited = set()
    visited.add(employee)
    subordinates = []
    for sub in employee.subordinates:
        if sub not in visited:
            subs = get_all_subordinates(sub, visited)
            subordinates.extend(subs)
    subordinates.append(employee)
    print(subordinates)
    return subordinates
# Example usage
employees = [
    Employee(1, "John"),
    Employee(2, "Peter", boss=1),
    Employee(3, "Mary", boss=1),
    Employee(4, "David", boss=2),
    Employee(5, "Linda", boss=2),
    Employee(6, "Steven", boss=3),
    Employee(7, "Karen", boss=5)]